import json
from db import get_db
import random

def calcRecommendation(watched_name, watched_cat):
    db = get_db()
    watchedSameCat = 2
    watchedExhibit = 0.9
    otherExhibit = 1

    weights_sum = 0
    lastRow = db.execute("SELECT * FROM recommend WHERE ID=(SELECT MAX(ID) FROM recommend)").fetchone()
    newData = json.loads(lastRow["data"])
    print(newData)
    for exhibit_data in newData:
        if watched_name != exhibit_data["e_name"] and watched_cat == exhibit_data["e_cat"]:
            exhibit_data["e_prop"] = exhibit_data["e_prop"] * watchedSameCat
            weights_sum += exhibit_data["e_prop"]
        elif watched_name == exhibit_data["e_name"]:
            exhibit_data["e_prop"] = exhibit_data["e_prop"] * watchedExhibit
            weights_sum += exhibit_data["e_prop"]
        else:
            exhibit_data["e_prop"] = exhibit_data["e_prop"] * otherExhibit
            weights_sum += exhibit_data["e_prop"]

    for exhibit_data in newData:
        exhibit_data["e_prop"] = exhibit_data["e_prop"] / weights_sum
    return newData


def recommendExhibit(watched_exhibit):
    db = get_db()
    exhibitNames = []
    weights = []
    currentRow = db.execute("SELECT * FROM recommend WHERE ID=(SELECT MAX(ID) FROM recommend)")
    for data_set in currentRow:
        data = json.loads(data_set["data"])
        for exhibit_data in data:
            print exhibit_data
            if exhibit_data["e_name"] != watched_exhibit:
                weights.append(exhibit_data["e_prop"])
                exhibitNames.append(exhibit_data["e_name"])
    recommendedExhibit = weightedRands(exhibitNames, weights)
    return recommendedExhibit

# returns random value from exhibitNames list weighted by the e_props
# Retrieved from: https://stackoverflow.com/questions/12096819
def weightedRands(exhibits, weights):
    r = random.uniform(0, sum(weights))
    for n,v in map(None, exhibits,[sum(weights[:x+1]) for x in range(len(weights))]):
        if r < v:
            return n