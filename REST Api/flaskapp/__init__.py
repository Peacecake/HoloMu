import os

from flask import Flask


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

    @app.route("/recognize", methods=["PUT"])
    def recognize_image():
        # Handle file upload: http://flask.pocoo.org/docs/1.0/patterns/fileuploads/
        return "<item id='2o8ru2309'><name>Comodore64</name><category>computer</category><year>1988</year><manufacturer>HansWurst</manufacturer><description>Ein kurze Beschreibung des Objekts</description><moreinfos><moreinfoitem type='Geschichte'>Die Geschichte des Commodore ist wahnsinnig spannend</moreinfoitem><moreinfoitem type='Technische Spezifikation'>Das technische BlaBla ist nicht so spannend.</moreinfoitem><moreinfoitem type='Anwendungen'>Zocken!!!</moreinfoitem></moreinfos></item>"

    @app.route("/recommend")
    def recommend_exhibit():
        return "Alle Exponate sind super!"

    from . import db
    db.init_app(app)

    return app
