using System;
using System.IO;
using System.Collections.Generic;

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
        /// This method expect the CSV ile path
        /// </summary>
        /// <param name="csvFilePath"></param>
        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }


        /// <summary>
        /// Este método será um dicionario com a lista das regiões da cada pais
        /// <para> 1 ler o arquivo</para>
        ///    <para>     2 verifico se a chave existe no dicionario</para>
        ///     <para>      - ContainsKey: true = >(região está no dicionario) --> adiciono novo pais ao dicionario </para>
        ///      <para>     - ContainsKey: false => (região não está no dicionario)--> crio lista de paises para a região e add ao Dicionario
        /// </para>
        /// </summary>
        /// <param name="nCountries"></param>
        /// <returns></returns>
        public Dictionary<string, List<Country>> ReadAllCountries()
        {
             var countries = new Dictionary<string, List<Country>> ();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    if (countries.ContainsKey(country.Region))
                    {
                        countries[country.Region].Add(country);
                    }
                    else
                    {
                        List<Country> countriesInRegion = new List<Country>() { country };
                        countries.Add(country.Region, countriesInRegion);
                    }
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
            string name, code, region, text;

            switch(parts.Length)
            {
                case 4: // paises com um único nome
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    text = parts[3];
                    break;
                case 5: //paises com nome  composto 
                    name = parts[0] + ","+ parts[1];
                    name = name.Replace("\"", null).Trim();//remove as aspas-duplas
                    code = parts[2];
                    region = parts[3];
                    text = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from file: {csvLine}");
            }

            //if population be unknown will return 0
            int.TryParse(text,out int population);
            return new Country(name, code, region, population);

        }



        #endregion
    }
}
