import os

from flask import Flask, request, Response
from uploader import Uploader
from xmlParser import XMLParser
from jsonParser import JsonParser

def create_app(test_config=None):
    app = Flask(__name__, instance_relative_config=None)
    app.config.from_mapping(
        SECRET_KEY="dev",
        DATABASE=os.path.join(app.instance_path, "flaskapp.sqlite")
    )

    if test_config is None:
        app.config.from_pyfile("config.py", silent=True)
    else:
        app.config.from_mapping(test_config)

    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    @app.route("/")
    def hello_world():
        return "Hello World"

    @app.route("/recognize", methods=["POST"])
    def recognize_image():
        upl = Uploader(request.files, "file")
        upload_result = upl.upload()
        if upload_result is not True:
            return Response(upload_result, status=500)

        # Image recognition stuff comes here
        print ("Recognizing image: " + upl.uploaded_file)

        jp = JsonParser(os.path.join(os.getcwd(), "flaskapp", "data.JSON"))
        jp.parse()
        exh = jp.get_item_by_id(235)

        # upl.delete_file()

        return exh

    @app.route("/recommend")
    def recommend_exhibit():
        return "Alle Exponate sind super!"

    from . import db
    db.init_app(app)

    return app
