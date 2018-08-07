#!/bin/bash
app_name=flaskapp
env_mode=development

echo "Setting environment variables..."
set FLASK_APP=$app_name
set FLASK_ENV=$env_mode
echo "Done."
echo "FLASK_APP is $FLASK_APP"
echo "FLASK_ENV is $FLASK_ENV"

pip install -e .

if "$1" == "public" (
    echo "Running server publicly in network..."
    flask run --host=0.0.0.0
) ELSE (
    echo "Running server locally..."
    flask run
)