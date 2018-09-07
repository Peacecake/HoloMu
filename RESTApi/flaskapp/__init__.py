import os

from flask import Flask, request, Response
from uploader import Uploader
from xmlParser import XMLParser
from jsonParser import JsonParser
from . import trainAndTest
from . import label_image
from db import init_db, get_db

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

    from . import db
    db.init_app(app)

    import routes
    app.register_blueprint(routes.bp)
    
    return app
