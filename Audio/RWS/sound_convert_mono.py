import os
from pydub import AudioSegment

# Specify the path to ffmpeg executable
ffmpeg_path = "C:\\ffmpeg\\bin\\ffmpeg.exe"

# Setting the converter for pydub
AudioSegment.converter = ffmpeg_path

def convert_wav_to_mono(directory_path):
    # Checking if the directory exists
    if not os.path.exists(directory_path):
        print(f"The directory {directory_path} does not exist.")
        return

    # Listing files in the directory
    files = os.listdir(directory_path)

    # Filtering .wav audio files
    wav_files = [f for f in files if f.endswith('.wav')]

    if not wav_files:
        print("No .wav audio files found in the directory.")
        return

    # Converting each .wav file to mono
    for wav_file in wav_files:
        wav_path = os.path.join(directory_path, wav_file)
        # Reading .wav audio file
        audio = AudioSegment.from_file(wav_path)
        # Converting to mono
        mono_audio = audio.set_channels(1)
        # Exporting as mono
        mono_audio.export(wav_path, format="wav")
        print(f"Converted {wav_file} to mono")

# You can call this function with the path to your directory as an argument
convert_wav_to_mono(os.path.dirname(os.path.realpath(__file__)))
