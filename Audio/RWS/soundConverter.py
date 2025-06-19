import os
from pydub import AudioSegment

# Specify the path to ffmpeg executable
ffmpeg_path = "C:\\ffmpeg\\bin\\ffmpeg.exe"

# Setting the converter for pydub
AudioSegment.converter = ffmpeg_path

def convert_ogg_to_wav(directory_path):
    # Checking if the directory exists
    if not os.path.exists(directory_path):
        print(f"The directory {directory_path} does not exist.")
        return

    # Listing files in the directory
    files = os.listdir(directory_path)

    # Filtering .ogg files
    ogg_files = [f for f in files if f.endswith('.ogg')]

    if not ogg_files:
        print("No .ogg files found in the directory.")
        return

    # Converting each .ogg file to .wav
    for ogg_file in ogg_files:
        ogg_path = os.path.join(directory_path, ogg_file)
        wav_path = os.path.join(directory_path, os.path.splitext(ogg_file)[0] + '.wav')

        # Reading .ogg file
        audio = AudioSegment.from_ogg(ogg_path)

        # Exporting as .wav
        audio.export(wav_path, format='wav')
        print(f"Converted {ogg_file} to {os.path.basename(wav_path)}")


# You can call this function with the path to your directory as an argument
convert_ogg_to_wav('C:/Users/DRAGON/AppData/Roaming/SpaceEngineers/Mods/L.Y.N.X-Naval-Division-DEV/Audio/RWS')
