using PersonRepository.CSV;
using PersonRepository.Factory;
using PersonRepository.Interface;
using PersonRepository.SQL;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {

            //ClearListBox();
            //IPersonRepository repository = new ServiceRepository();
            //var people = repository.GetPeople();
            //foreach (var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}

            //ShowRepositoryType(repository);// this will print out the type of repository

            PopulateListBox("Service");//using  The Factory Method Pattern
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {

            //ClearListBox();

            //IPersonRepository repository = new CSVRepository ();
            //var people = repository.GetPeople();
            //foreach (var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}

            //ShowRepositoryType(repository);


             PopulateListBox("CSV");//using  The Factory Method Pattern
        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {

            //ClearListBox();

            //IPersonRepository repository = new SQLRepository();
            //var people = repository.GetPeople();
            //foreach (var person in people)
            //{
            //    PersonListBox.Items.Add(person);
            //}

            //ShowRepositoryType(repository);
            PopulateListBox("SQL"); //using  The Factory Method Pattern
        }

        private void PopulateListBox(string repositoryType)
        {
            ClearListBox();

            IPersonRepository repository =   RepositoryFactory.GetRepository(repositoryType);

            var people = repository.GetPeople();
            foreach (var person in people)
                PersonListBox.Items.Add(person);

            ShowRepositoryType(repository);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
            RepositoryTypeTextBlock.Text = string.Empty;
        }
        /// <summary>
        /// this method get type of repository , convert to string  and it can be display in text box
        /// </summary>
        /// <param name="repository"></param>
        private void ShowRepositoryType(IPersonRepository repository)
        {
            RepositoryTypeTextBlock.Text = repository.GetType().ToString();
        }
    }
}
