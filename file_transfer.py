import os
import shutil

target_folder = r'C:\Users\Justin\Desktop\Freelance\Monument\03_PRODUCTION\Assets\Monument_Images_From_Client\Monument_Images' + '\\'
source_folder = r'C:\Users\Justin\Desktop\Freelance\Monument\03_PRODUCTION\Assets\Monument_Images_From_Client\Single Uprights' + '\\'


def move_files(sourceFolder, targetFolder):
    try:
        for path, dir, files in os.walk(sourceFolder):
            if files:
                for file in files:
                    if not os.path.isfile(targetFolder + file):
                        os.rename(path + '\\' + file, targetFolder + file)              
        print('Files have been moved')
    except Exception as e:
        print(e)

move_files(source_folder, target_folder)
