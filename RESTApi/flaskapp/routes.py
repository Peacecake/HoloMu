from flask import Blueprint, request, Response
from db import get_db
from db import init_db
from uploader import Uploader
from jsonParser import JsonParser
import json
from . import trainAndTest
from . import label_image
import os
from collections import Counter

bp = Blueprint("routes", __name__)

@bp.route("/")
def hello_world():
    #init_db()
    db = get_db()
    result = db.execute("SELECT * FROM data;").fetchall()
    print (result)
    return "Hello World!"

@bp.route("/setup")
def setup():
    # init_db()
    trainAndTest.train()
    return "success"

@bp.route("/recognize", methods=["POST"])
def recognize_image():
    upl = Uploader(request.files, "file")
    upload_result = upl.upload()
    if upload_result is not True:
        return Response(upload_result, status=500)

    # Image recognition stuff comes here
    print "testImagePath " + upl.uploaded_file
    objectId = trainAndTest.trainOrTest(upl.uploaded_file)
    print ("Recognizing image: " + upl.uploaded_file)
    print "-----------"
    print objectId
    print "-----------"
    if objectId is None:
        return Response("Bild nicht erkannt", status=500)
    jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
    jp.parse()
    objectId = 174
    exh = jp.get_item_by_id(objectId)

    #db = get_db()
    #db.execute("INSERT INTO data (e_id, e_category) VALUES (?, ?)", (objectId, jp.get_value_by_key(objectId, "category")));
    #db.commit()
    #res = db.execute("SELECT * from data;").fetchall()
    #print(res)

    # upl.delete_file()
    return exh

@bp.route("/recommend/<int:watched_exhibit_id>")
def recommend_exhibit(watched_exhibit_id):
    ##category = db.execute("SELECT e_category from data;").fetchall()
    #category = db.execute("SELECT e_category, count(*) FROM data GROUP BY e_category;").fetchall()
    ##recommendList = []
    ##resultList = []
    #maxProp = 100
    #defaultProp = 0.5
    #for element in range(len(category)):
    #    dictElement = dict(category[element])
    #    watchedCount = dictElement["count(*)"]
    #    currentRecommendResult = maxProp - (1/(defaultProp * watchedCount) *50) #die 50 ist eine magic number um den Wert deutlicher zu machen, da er aber auf beide Berechnungen angewandt wird darf man es machen(kommutativ oder so?)
    #    #recommendList.append(dictElement["e_category"] + ";" +str(currentRecommendResult))
    #    #result = searchForHighestValue(recommendList, currentRecommendResult)
    #    zwischenergebnis = dictElement["e_category"] + ";" + str(currentRecommendResult) +"%"
    #    print zwischenergebnis
    #    #resultList.append(zwischenergebnis.split(";")[1])
    #init_db()
    print (watched_exhibit_id)

    jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
    jp.parse()
    e_name = jp.get_value_by_key(watched_exhibit_id, "name")
    e_cat = jp.get_value_by_key(watched_exhibit_id, "category")
    print(e_name, e_cat)

    db = get_db()
    result = db.execute("SELECT * FROM recommend;").fetchall()
    for data_set in result:
        x = json.loads(data_set["data"])
        print(x)
        print(type(x))
        for exhibit_data in x:
            print exhibit_data["e_name"]
            print exhibit_data["e_prop"]



    return "Alle Exponate sind super!"