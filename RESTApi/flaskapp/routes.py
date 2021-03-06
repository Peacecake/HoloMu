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

    # Image recognition
    objectId = trainAndTest.trainOrTest(upl.uploaded_file)
    if objectId is "":
        return Response("Bild nicht erkannt", status=500)
    jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
    jp.parse()
    exh = jp.get_item_by_id(objectId)

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

    recommendedExhibit = recommend.recommendExhibit(watched_name)

    return "Vielleicht interessiert Sie das besonders: " + recommendedExhibit

