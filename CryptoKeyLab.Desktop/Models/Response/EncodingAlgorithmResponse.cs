using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Models.Response
{
    public class EncodingAlgorithmResponse : ObservableObject
    {
        private int id { get; set; }
        private string? name;
        private string? family;
        private string? category;
        private int sortOrder;
        private bool isActive;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string? Family
        {
            get => family;
            set
            {
                family = value;
                OnPropertyChanged(nameof(Family));
            }
        }
        public string? Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public int SortOrder
        {
            get => sortOrder;
            set
            {
                sortOrder = value;
                OnPropertyChanged(nameof(SortOrder));
            }
        }
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

    }
}
