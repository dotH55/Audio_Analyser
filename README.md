# Audio_Analyser
Spectrum is an android application that captures microphone audio data in real time and displays frequency and amplitude.


Fast Fourier Transform
Fast Fourier Transformation (FFT) is a mathematical algorithm that calculates Discrete Fourier Transform (DFT) of a given sequence. The only difference between FT (Fourier Transform) and FFT is that FT considers a continuous signal while FFT takes a discrete signal as input. DFT converts a sequence (discrete signal) into its frequency constituents just like FT does for a continuous signal. In our case, we have a sequence of amplitudes that were sampled from a continuous audio signal. DFT or FFT algorithm can convert this time-domain discrete signal into a frequency-domain.

How To:
First, we need to define a sample rate. sample rate = 44100 says that this audio was recorded(sampled) with a sampling frequency of 44100. In other words, while
recording this file we were capturing 16000 amplitudes every second.
We also need to define a buffer size. The buffer size refers to the width of the chunk that is being analyzed with the FFT. Changing the size of the buffer would result in different frequency resolutions.
We then determine which audio device to use (Device Mic) and start recording.
In a loop, the program calls a method named GetFrequency() which return an integer value of the frequency. Inside GetFrequency(), real time data are read into our buffer.

Algorithm A
Define BufferSize Define Sample_Size
Attach Buffer to a Sound Card
Start Recording
Loop: Read Real Time Data Find Number of crossing Find Time Find Number Cycle Find Frequency (Cycle / Time)
Amplitude is obtained by calling MaxAmplitude on
Sound Card or Mic.

Algorithm B
Algorithm B uses a C# built-in function to calculate the FFT. The FFT, or Fast Fourier Transform, is an algorithm for quickly computing the frequencies that comprise a given signal. By quickly, we mean O (NlogN). The FFT works on a chunk of samples at a time. The FFT works on a chunk of samples at a time. You don't get more or less data out of a Fourier Transform than you put into it, you just get it in another form. That means that if you put ten audio samples in you get ten data-points out. The difference is that these ten data points now represent energy at different frequencies instead of energy at different times, and since our data uses real numbers, and not complex, the FFT will contain some redundancies -- specifically, only the first half of the spectrum contains relevant data. That
means that for ten samples in, we really only get five relevant data-points out.
Define BufferSize Define Sample_Size
Attach Buffer to a Sound Card
Start Recording
Loop: Read Real Time Data Apply FFT to Data
Now that we know the magnitude of each FFT chunk, finding the frequency is simply a matter of finding the bin with the maximum magnitude. The frequency will then be the bin number times the bin size.
Both Algorithms are implemented into program.
