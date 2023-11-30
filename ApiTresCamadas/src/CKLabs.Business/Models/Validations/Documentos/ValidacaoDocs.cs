namespace CKLabs.Business.Models.Validations.Documentos
{
    /// <summary>
    /// Classe de validação de CPF
    /// </summary>
    public class CpfValidacao
    {
        /// <summary>
        /// Tamanho do CPF
        /// </summary>
        public const int TamanhoCpf = 11;

        /// <summary>
        /// Método de validação
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool Validar(string cpf)
        {
            var cpfNumeros = Utils.ApenasNumeros(cpf);

            if (!TamanhoValido(cpfNumeros)) return false;
            return !TemDigitosRepetidos(cpfNumeros) && TemDigitosValidos(cpfNumeros);
        }

        /// <summary>
        /// Verifica se o tamanho do CPF é válido
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static bool TamanhoValido(string valor)
        {
            return valor.Length == TamanhoCpf;
        }

        /// <summary>
        /// Verifica se o CPF possui dígitos repetidos
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static bool TemDigitosRepetidos(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(valor);
        }

        /// <summary>
        /// Verifica se o CPF possui dígitos válidos
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static bool TemDigitosValidos(string valor)
        {
            var number = valor.Substring(0, TamanhoCpf - 2);
            var digitoVerificador = new DigitoVerificador(number)
                .ComMultiplicadoresDeAte(2, 11)
                .Substituindo("0", 10, 11);
            var firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            var secondDigit = digitoVerificador.CalculaDigito();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCpf - 2, 2);
        }
    }

    /// <summary>
    /// Classe de validação de CNPJ
    /// </summary>
    public class CnpjValidacao
    {
        /// <summary>
        /// Tamnho do CNPJ
        /// </summary>
        public const int TamanhoCnpj = 14;

        /// <summary>
        /// Método de validação
        /// </summary>
        /// <param name="cpnj"></param>
        /// <returns></returns>
        public static bool Validar(string cpnj)
        {
            var cnpjNumeros = Utils.ApenasNumeros(cpnj);

            if (!TemTamanhoValido(cnpjNumeros)) return false;
            return !TemDigitosRepetidos(cnpjNumeros) && TemDigitosValidos(cnpjNumeros);
        }

        /// <summary>
        /// Verifica se o tamanho do CNPJ é válido
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static bool TemTamanhoValido(string valor)
        {
            return valor.Length == TamanhoCnpj;
        }

        /// <summary>
        /// Verifica se o CNPJ possui dígitos repetidos
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static bool TemDigitosRepetidos(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(valor);
        }

        /// <summary>
        /// Verifica se o CNPJ possui dígitos válidos
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static bool TemDigitosValidos(string valor)
        {
            var number = valor.Substring(0, TamanhoCnpj - 2);

            var digitoVerificador = new DigitoVerificador(number)
                .ComMultiplicadoresDeAte(2, 9)
                .Substituindo("0", 10, 11);
            var firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            var secondDigit = digitoVerificador.CalculaDigito();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCnpj - 2, 2);
        }
    }

    /// <summary>
    /// Classe de cálculo de dígito verificador
    /// </summary>
    public class DigitoVerificador
    {
        private string _numero;
        private const int Modulo = 11;
        private readonly List<int> _multiplicadores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substituicoes = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="numero"></param>
        public DigitoVerificador(string numero)
        {
            _numero = numero;
        }

        /// <summary>
        /// Calcular multiplicadores
        /// </summary>
        /// <param name="primeiroMultiplicador"></param>
        /// <param name="ultimoMultiplicador"></param>
        /// <returns></returns>
        public DigitoVerificador ComMultiplicadoresDeAte(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multiplicadores.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                _multiplicadores.Add(i);

            return this;
        }

        /// <summary>
        /// Substituir dígito
        /// </summary>
        /// <param name="substituto"></param>
        /// <param name="digitos"></param>
        /// <returns></returns>
        public DigitoVerificador Substituindo(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _substituicoes[i] = substituto;
            }
            return this;
        }

        /// <summary>
        /// Adicionar dígito
        /// </summary>
        /// <param name="digito"></param>
        public void AddDigito(string digito)
        {
            _numero = string.Concat(_numero, digito);
        }

        /// <summary>
        /// Calcular dígito
        /// </summary>
        /// <returns></returns>
        public string CalculaDigito()
        {
            return !(_numero.Length > 0) ? "" : GetDigitSum();
        }

        /// <summary>
        /// Calcular soma dos dígitos
        /// </summary>
        /// <returns></returns>
        private string GetDigitSum()
        {
            var soma = 0;
            for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                soma += produto;

                if (++m >= _multiplicadores.Count) m = 0;
            }

            var mod = (soma % Modulo);
            var resultado = _complementarDoModulo ? Modulo - mod : mod;

            return _substituicoes.ContainsKey(resultado) ? _substituicoes[resultado] : resultado.ToString();
        }
    }

    /// <summary>
    /// Classe de utilidades
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Retorna apenas os números de uma string
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string ApenasNumeros(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
