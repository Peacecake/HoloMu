from flask import Blueprint, request, Response
from db import get_db
from uploader import Uploader
from jsonParser import JsonParser
from . import trainAndTest
from . import label_image
import os

bp = Blueprint("routes", __name__)

@bp.route("/")
def hello_world():
    # init_db()
    db = get_db()
    result = db.execute("SELECT * FROM data;").fetchall()
    print (result)
    return "Hello World!"

@bp.route("/setup")
def setup():
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
    jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
    jp.parse()
    exh = jp.get_item_by_id(objectId)

    db = get_db()
    db.execute("INSERT INTO data (e_id, e_category) VALUES (?, ?)", (objectId, jp.get_value_by_key(objectId, "category")));
    db.commit()
    res = db.execute("SELECT * from data;").fetchall()
    print(res)

    upl.delete_file()
    return exh

@bp.route("/recommend")
def recommend_exhibit():
    return "Alle Exponate sind super!"