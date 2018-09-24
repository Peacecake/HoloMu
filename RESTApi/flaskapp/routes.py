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
import recommend

bp = Blueprint("routes", __name__)

@bp.route("/")
def hello_world():
    init_db()
    db = get_db()
    result = db.execute("SELECT * FROM data;").fetchall()
    print (result)
    return "Hello World!"

@bp.route("/setup")
def setup():
    init_db()
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
    if objectId is "":
        return Response("Bild nicht erkannt", status=500)
    jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
    jp.parse()
    #objectId = 174
    exh = jp.get_item_by_id(objectId)

    db = get_db()
    db.execute("INSERT INTO data (e_id, e_category) VALUES (?, ?)", (objectId, jp.get_value_by_key(objectId, "category")));
    db.commit()
    res = db.execute("SELECT * from data;").fetchall()

    upl.delete_file()
    return exh

@bp.route("/recommend/<string:watched_exhibit_id>")
def recommend_exhibit(watched_exhibit_id):
    db = get_db()
    jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
    jp.parse()
    watched_name = jp.get_value_by_key(watched_exhibit_id, "name")
    watched_cat = jp.get_value_by_key(watched_exhibit_id, "category")

    recommendData = recommend.calcRecommendation(watched_name, watched_cat)
    db.execute("INSERT INTO recommend (data) VALUES (?)", (json.dumps(recommendData),))
    db.commit()

    recommendedExhibit = recommend.recommendExhibit()

    return "Alle Exponate sind super! Vll interessiert dich das besonders: " + recommendedExhibit

