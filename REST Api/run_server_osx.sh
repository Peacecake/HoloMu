#!/bin/bash
app_name=flaskapp
env_mode=development

echo "Setting environment variables..."
export FLASK_APP=$app_name
export FLASK_ENV=$env_mode
echo "Done."
echo "FLASK_APP is $FLASK_APP"
echo "FLASK_ENV is $FLASK_ENV"

echo "Installation of flask app need admin rights!"
sudo pip install -e .

if [ $1 == "public" ]
then
    echo "Running server publicly in network..."
    flask run --host=0.0.0.0
else
    echo "Running server locally..."
    flask run
fi