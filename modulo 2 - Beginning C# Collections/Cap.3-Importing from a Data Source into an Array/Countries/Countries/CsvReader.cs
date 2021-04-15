using System;
using System.IO;

namespace Countries
{
    class CsvReader
    {
        #region Field
        //var irá informar o caminho da fonte de dados
        private string _csvFilePath;
        #endregion

        #region Methods

        /// <summary>
        /// Este método espera receber o caminho do arquivo CSV
        /// </summary>
        /// <param name="csvFilePath"></param>
        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }


        /// <summary>
        /// Este método lê os países do arquivo e retorna os dados de cada país
        /// <para> O parâmetro int, indica a quantidade de países que serão lidos</para>
        /// </summary>
        /// <param name="nCountries"></param>
        /// <returns></returns>
        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath)) 
            {
                sr.ReadLine(); // linha do cabeçalho

                for (int index =0; index < nCountries; index++)
                {
                    string csvLine = sr.ReadLine();
                    countries[index] = ReadCountryFromCsvLine(csvLine);
                }
            
            }
            return countries;
        }


        /// <summary>
        /// Este método recebe como argumento  o dado de cada linha do arquivo CSV referente a um país
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns></returns>
        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);

        }



        #endregion
    }
}
