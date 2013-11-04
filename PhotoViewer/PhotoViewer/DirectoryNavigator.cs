using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace PhotoViewer
{
    public static class DirectoryNavigator
    {
        private static String _currentDirectory;
        private static String[] _allFiles;
        private static String[] _filteredFiles;
        private static String _currentImage;
        private static int _currentImageOffset;

        public static String CurrentDirectory
        {
            get { return _currentDirectory; }
            set
            {
                if (value.Equals(_currentDirectory, StringComparison.OrdinalIgnoreCase)) { return; }
                _currentDirectory = value;
                UpdateFiles();
                _currentImageOffset = 0;
            }
        }

        public static String CurrentImage
        {
            get { return _currentImage; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) { return; }
                String path = Path.GetDirectoryName(value);
                CurrentDirectory = path;

                int offset = -1;
                for (int i = 0; i < _filteredFiles.Length; i++)
                {
                    if(_filteredFiles[i].Equals(value, StringComparison.OrdinalIgnoreCase)) { offset = i; }
                }
                if (offset >= 0)
                {
                    _currentImage = value;
                    _currentImageOffset = offset;
                }
                else
                {
                    throw new Exception("The specified image is not supported.");
                }
            }
        }

        public static String[] Images
        {
            get { return _filteredFiles; }
        }

        public static int CurrentImageOffset
        {
            get { return _currentImageOffset; }
        }

        public static String MoveNext()
        {
            int maxIndex = _filteredFiles.Length - 1;
            int requestedOffset = _currentImageOffset + 1;

            if (requestedOffset > maxIndex)
            {
                requestedOffset = 0;
            }
            CurrentImage = _filteredFiles[requestedOffset];
            return CurrentImage;
        }

        public static String MovePrevious()
        {
            int maxIndex = _filteredFiles.Length - 1;
            int requestedOffset = _currentImageOffset - 1;

            if (requestedOffset < 0)
            {
                requestedOffset = maxIndex;
            }
            CurrentImage = _filteredFiles[requestedOffset];
            return CurrentImage;
        }

        private static void UpdateFiles()
        {
            _allFiles = Directory.GetFiles(_currentDirectory);
            FilterFiles();
        }

        private static void FilterFiles()
        {
            String[] supportedFormats = new[] {".xaml", ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp", ".ico"};
            List<String> supportedImageFiles = _allFiles.Where(file => supportedFormats.Any(file.EndsWith)).ToList();
            _filteredFiles = supportedImageFiles.ToArray();
        }


        static DirectoryNavigator()
        {
            _currentDirectory = "";
        }
    }
}
