import os
from werkzeug.utils import secure_filename

# Base on: http://flask.pocoo.org/docs/1.0/patterns/fileuploads/
class Uploader:
    def __init__(self, files, key):
        self.files = files
        self.key = key
        self.uploaded_file = ""
        self.ALLOWED_FILES = ["jpg", "bmp", "png", "jpeg"]
        self.UPLOAD_PATH = os.path.join(os.getcwd(), "flaskapp", "tmp")

    def upload(self):
        check_file_result = self.check_files()
        if check_file_result is not True:
            return check_file_result
        
        file = self.files[self.key]
        if file and self.allow_file(file.filename):
            self.create_upload_folder()
            filename = secure_filename(file.filename)
            self.uploaded_file = os.path.join(self.UPLOAD_PATH, filename)
            file.save(self.uploaded_file)
            return True
        return "unallowed file type"
    
    def delete_file(self):
        if self.uploaded_file is not "":
            os.remove(self.uploaded_file)

    def check_files(self):
        if self.key not in self.files:
            return "no key " + self.key + " in files"
        if len(self.files) > 1:
            return "only single file upload supported"
        return True

    def create_upload_folder(self):
        if not os.path.exists(self.UPLOAD_PATH):
            os.makedirs(self.UPLOAD_PATH)

    def allow_file(self, filename):
        return '.' in filename and \
           filename.rsplit('.', 1)[1].lower() in self.ALLOWED_FILES