import json
from db import get_db
import random

def calcRecommendation(watched_name, watched_cat):
    db = get_db()
    propSumOtherCat = []
    watchedSameCat = 1.9
    watchedExhibit = 0.2

    lastRow = db.execute("SELECT * FROM recommend WHERE ID=(SELECT MAX(ID) FROM recommend)");
    for data_set in lastRow:
        newData = json.loads(data_set["data"])
        for exhibit_data in newData:
            if watched_name != exhibit_data["e_name"] and watched_cat == exhibit_data["e_cat"]:
                exhibit_data["e_prop"] = exhibit_data["e_prop"] * watchedSameCat
                propSumOtherCat.append(exhibit_data["e_prop"])
            elif watched_name == exhibit_data["e_name"]:
                exhibit_data["e_prop"] = exhibit_data["e_prop"]* watchedExhibit
                propSumOtherCat.append(exhibit_data["e_prop"])
        for exhibit_data in newData:
            if watched_cat != exhibit_data["e_cat"]:
                exhibit_data["e_prop"] = (1.0 - float(sum(propSumOtherCat))) / 3.0
        return newData

def recommendExhibit():
    db = get_db()
    exhibitNames = []
    weights = []
    currentRow = db.execute("SELECT * FROM recommend WHERE ID=(SELECT MAX(ID) FROM recommend)");
    for data_set in currentRow:
        data = json.loads(data_set["data"])
        for exhibit_data in data:
            print exhibit_data
            weights.append(exhibit_data["e_prop"])
            exhibitNames.append(exhibit_data["e_name"])
    recommendedExhibit = weightedRands(exhibitNames, weights)
    return recommendedExhibit

# returns random value from exhibitNames list weighted by the e_props
def weightedRands(exhibits, weights):
    r = random.uniform(0, sum(weights))
    for n,v in map(None, exhibits,[sum(weights[:x+1]) for x in range(len(weights))]):
        if r < v:
            return n