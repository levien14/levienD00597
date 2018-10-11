using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TessFile.NewFolder1;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TessFile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Member currenMember1;
        
        public MainPage()
        {
            currenMember1 = new Member();
            this.InitializeComponent();
        }

        private async void SaveFile(object sender, RoutedEventArgs e)
        {
            currenMember1.email = Temail.Text;
            currenMember1.password = password.Password;
            currenMember1.address = Taddress.Text;
            currenMember1.phoneNumber = Tphone.Text;

            string content = JsonConvert.SerializeObject(currenMember1);
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt"});
            savePicker.SuggestedFileName = "";
            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            await FileIO.WriteTextAsync(file, content);
        }

        private async void LoadFile(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            string content = await FileIO.ReadTextAsync(file);
            Member currenMember2 = JsonConvert.DeserializeObject<Member>(content);
            Temail.Text = currenMember2.email;
            password.Password = currenMember2.password;
            Taddress.Text = currenMember2.address;
            Tphone.Text = currenMember2.phoneNumber;

        }
    }
}
