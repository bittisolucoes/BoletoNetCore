using System;

namespace BoletoNetCore
{
    public class TCampoRegistroEDI
    {
        #region Variáveis Privadas
        private string _DescricaoCampo;
        private TTiposDadoEDI _TipoCampo;
        private int _TamanhoCampo;
        private int _QtdDecimais;
        private object _ValorNatural;
        private string _ValorFormatado;
        private int _OrdemNoRegistroEDI;
        private string _SeparadorDatas;
        private string _SeparadorHora;
        private int _PosicaoInicial;
        private int _PosicaoFinal;
        private char _Preenchimento = ' ';
        #endregion

        #region Propriedades
        /// <summary>
        /// Descrição do campo no registro EDI (meramente descritivo)
        /// </summary>
        public string DescricaoCampo
        {
            get { return _DescricaoCampo; }
            set { _DescricaoCampo = value; }
        }

        /// <summary>
        /// Tipo de dado de ORIGEM das informações do campo EDI.
        /// </summary>
        public TTiposDadoEDI TipoCampo
        {
            get { return _TipoCampo; }
            set { _TipoCampo = value; }
        }

        /// <summary>
        /// Tamanho em caracteres do campo no arquivo EDI (DESTINO)
        /// </summary>
        public int TamanhoCampo
        {
            get { return _TamanhoCampo; }
            set { _TamanhoCampo = value; }
        }

        /// <summary>
        /// Quantidade de casas decimais do campo, caso ele seja do tipo numérico sem decimais. Caso
        /// não se aplique ao tipo de dado, o valor da propriedade será ignorado nas funções de formatação.
        /// </summary>
        public int QtdDecimais
        {
            get { return _QtdDecimais; }
            set { _QtdDecimais = value; }
        }

        /// <summary>
        /// Valor de ORIGEM do campo, sem formatação, no tipo de dado adequado ao campo. O valor deve ser atribuido
        /// com o tipo de dado adequado ao seu proposto, por exemplo, Double para representar valor, DateTime para
        /// representar datas e/ou horas, etc.
        /// </summary>
        public object ValorNatural
        {
            get { return _ValorNatural; }
            set { _ValorNatural = value; }
        }

        /// <summary>
        /// Valor formatado do campo, pronto para ser utilizado no arquivo EDI. A formatação será de acordo
        /// com a especificada na propriedade TipoCampo, com numéricos alinhados à direita e zeros à esquerda
        /// e campos alfanuméricos alinhados à esquerda e com brancos à direita.
        /// Também pode receber o valor vindo do arquivo EDI, para ser decodificado e o resultado da decodificação na propriedade
        /// ValorNatural
        /// </summary>
        public string ValorFormatado
        {
            get { return _ValorFormatado; }
            set { _ValorFormatado = value; }
        }

        /// <summary>
        /// Número de ordem do campo no registro EDI
        /// </summary>
        public int OrdemNoRegistroEDI
        {
            get { return _OrdemNoRegistroEDI; }
            set { _OrdemNoRegistroEDI = value; }
        }

        /// <summary>
        /// Caractere separador dos elementos de campos com o tipo DATA. Colocar null caso esta propriedade
        /// não se aplique ao tipo de dado.
        /// </summary>
        public string SeparadorDatas
        {
            get { return _SeparadorDatas; }
            set { _SeparadorDatas = value; }
        }

        /// <summary>
        /// Caractere separador dos elementos de campos com o tipo HORA. Colocar null caso esta propriedade
        /// não se aplique ao tipo de dado.
        /// </summary>
        public string SeparadorHora
        {
            get { return _SeparadorHora; }
            set { _SeparadorHora = value; }
        }

        /// <summary>
        /// Posição do caracter inicial do campo no arquivo EDI
        /// </summary>
        public int PosicaoInicial
        {
            get { return _PosicaoInicial; }
            set { _PosicaoInicial = value; }
        }

        public int PosicaoFinal
        {
            get { return _PosicaoFinal; }
            set { _PosicaoFinal = value; }
        }
        /// <summary>
        /// Caractere de Preenchimento do campo da posição inicial até a posição final
        /// </summary>
        public char Preenchimento
        {
            get { return _Preenchimento; }
            set { _Preenchimento = value; }
        }
        #endregion

        #region Construtores
        /// <summary>
        /// Cria um objeto TCampoRegistroEDI
        /// </summary>
        public TCampoRegistroEDI()
        { 
        }

        /// <summary>
        /// Cria um objeto do tipo TCampoRegistroEDI inicializando as propriedades básicas.
        /// </summary>
        /// <param name="pTipoCampo">Tipo de dado de origem dos dados</param>
        /// <param name="pPosicaoInicial">Posição Inicial do Campo no Arquivo</param>
        /// <param name="pTamanho">Tamanho em caracteres do campo (destino)</param>
        /// <param name="pDecimais">Quantidade de decimais do campo (destino)</param>
        /// <param name="pValor">Valor do campo (Origem), no tipo de dado adequado ao propósito do campo</param>
        /// <param name="pPreenchimento">Caractere de Preenchimento do campo caso o valor não ocupe todo o tamanho</param>
        /// <param name="pSeparadorHora">Separador de hora padrão; null para sem separador</param>
        /// <param name="pSeparadorData">Separador de data padrão; null para sem separador</param>
        public TCampoRegistroEDI(TTiposDadoEDI pTipoCampo, int pPosicaoInicial, int pTamanho, int pDecimais, object pValor, char pPreenchimento, string pSeparadorHora, string pSeparadorData)
        {
            _TipoCampo = pTipoCampo;
            _TamanhoCampo = pTamanho;
            _QtdDecimais = pDecimais;
            _ValorNatural = pValor;
            _SeparadorHora = pSeparadorHora;
            _SeparadorDatas = pSeparadorData;
            _OrdemNoRegistroEDI = 0;
            _DescricaoCampo = "";
            _PosicaoInicial = pPosicaoInicial - 1; //Compensa a indexação com base em zero
            _PosicaoFinal = pPosicaoInicial + _TamanhoCampo;
            _Preenchimento = pPreenchimento;
        }
        /// <summary>
        /// Cria um objeto do tipo TCampoRegistroEDI inicializando as propriedades básicas.
        /// </summary>
        /// <param name="pTipoCampo">Tipo de dado de origem dos dados</param>
        /// <param name="pPosicaoInicial">Posição Inicial do Campo no Arquivo</param>
        /// <param name="pTamanho">Tamanho em caracteres do campo (destino)</param>
        /// <param name="pDecimais">Quantidade de decimais do campo (destino)</param>
        /// <param name="pValor">Valor do campo (Origem), no tipo de dado adequado ao propósito do campo</param>
        /// <param name="pPreenchimento">Caractere de Preenchimento do campo caso o valor não ocupe todo o tamanho</param>
        public TCampoRegistroEDI(TTiposDadoEDI pTipoCampo, int pPosicaoInicial, int pTamanho, int pDecimais, object pValor, char pPreenchimento)
        {
            _TipoCampo = pTipoCampo;
            _TamanhoCampo = pTamanho;
            _QtdDecimais = pDecimais;
            _ValorNatural = pValor;
            _SeparadorHora = null;
            _SeparadorDatas = null;
            _OrdemNoRegistroEDI = 0;
            _DescricaoCampo = "";
            _PosicaoInicial = pPosicaoInicial - 1; //Compensa a indexação com base em zero
            _PosicaoFinal = pPosicaoInicial + _TamanhoCampo;
            _Preenchimento = pPreenchimento;
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Aplica formatação ao valor do campo em ValorNatural, colocando o resultado na propriedade ValorFormatado
        /// </summary>
        public void CodificarNaturalParaEDI()
        {
            switch (_TipoCampo)
            {
                case TTiposDadoEDI.ediAlphaAliEsquerda_____:
                {
                    if (_ValorNatural != null)
                    {
                        if (_ValorNatural.ToString().Trim().Length >= _TamanhoCampo)
                            _ValorFormatado = _ValorNatural.ToString().Trim().Substring(0, _TamanhoCampo);
                        else
                            _ValorFormatado = _ValorNatural.ToString().Trim().PadRight(_TamanhoCampo, _Preenchimento); //' '
                    }
                    else
                        _ValorFormatado = string.Empty.PadRight(_TamanhoCampo, _Preenchimento); //' '
                    break;
                }
                case TTiposDadoEDI.ediAlphaAliDireita______:
                {
                    if (_ValorNatural != null)
                    {
                        if (_ValorNatural.ToString().Trim().Length >= _TamanhoCampo)
                            _ValorFormatado = _ValorNatural.ToString().Trim().Substring(0, _TamanhoCampo);
                        else
                            _ValorFormatado = _ValorNatural.ToString().Trim().PadLeft(_TamanhoCampo, _Preenchimento); //' '
                    }
                    else
                        _ValorFormatado = string.Empty.PadLeft(_TamanhoCampo, _Preenchimento); //' '
                    break;
                }
                case TTiposDadoEDI.ediInteiro______________:
                {
                    _ValorFormatado = _ValorNatural.ToString().Trim().PadLeft(_TamanhoCampo, _Preenchimento); //'0'
                    break;
                }
                case TTiposDadoEDI.ediNumericoSemSeparador_:
                {
                    if (_ValorNatural == null)
                    {
                        string aux = "";
                        _ValorFormatado = aux.Trim().PadLeft(_TamanhoCampo, ' ');//Se o Número for NULL, preenche com espaços em branco
                    }
                    else
                    {
                        string Formatacao = "{0:f" + _QtdDecimais.ToString() + "}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural).Replace(",", "").Replace(".", "").Trim().PadLeft(_TamanhoCampo, _Preenchimento); //'0'
                    }
                    break;
                }
                case TTiposDadoEDI.ediNumericoComPonto_____:
                {
                    string Formatacao = "{0:f" + _QtdDecimais.ToString() + "}";
                    _ValorFormatado = String.Format(Formatacao, _ValorNatural).Replace(",", ".").Trim().PadLeft(_TamanhoCampo, _Preenchimento); //'0'
                    break;
                }
                case TTiposDadoEDI.ediNumericoComVirgula___:
                {
                    string Formatacao = "{0:f" + _QtdDecimais.ToString() + "}";
                    _ValorFormatado = String.Format(Formatacao, _ValorNatural).Replace(".", ",").Trim().PadLeft(_TamanhoCampo, _Preenchimento); //'0'
                    break;
                }
                case TTiposDadoEDI.ediDataAAAAMMDD_________:
                {
                    if ( (DateTime)_ValorNatural != DateTime.MinValue)
                    {
                        string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                        string Formatacao = "{0:yyyy" + sep + "MM" + sep + "dd}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorNatural = "";
                        goto case TTiposDadoEDI.ediAlphaAliEsquerda_____;
                    }
                    break;
                }
                case TTiposDadoEDI.ediDataDDMM_____________:
                {
                    if ((DateTime)_ValorNatural != DateTime.MinValue)
                    {
                        string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                        string Formatacao = "{0:dd" + sep + "MM}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorNatural = "";
                        goto case TTiposDadoEDI.ediAlphaAliEsquerda_____;
                    }
                    break;
                }
                case TTiposDadoEDI.ediDataDDMMAAAA_________:
                {
                    if ((DateTime)_ValorNatural != DateTime.MinValue)
                    {
                        string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                        string Formatacao = "{0:dd" + sep + "MM" + sep + "yyyy}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorNatural = "";
                        goto case TTiposDadoEDI.ediAlphaAliEsquerda_____;
                    }
                    break;
                }
                case TTiposDadoEDI.ediDataDDMMAA___________:
                {
                    if ((DateTime)_ValorNatural != DateTime.MinValue)
                    {
                        string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                        string Formatacao = "{0:dd" + sep + "MM" + sep + "yy}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorNatural = "";
                        goto case TTiposDadoEDI.ediAlphaAliEsquerda_____;
                    }
                    break;
                }
                case TTiposDadoEDI.ediDataMMAAAA___________:
                {
                    if ((DateTime)_ValorNatural != DateTime.MinValue)
                    {
                        string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                        string Formatacao = "{0:MM" + sep + "yyyy}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorNatural = "";
                        goto case TTiposDadoEDI.ediAlphaAliEsquerda_____;
                    }
                    break;
                }
                case TTiposDadoEDI.ediDataMMDD_____________:
                {
                    if ((DateTime)_ValorNatural != DateTime.MinValue)
                    {
                        string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                        string Formatacao = "{0:MM" + sep + "dd}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorNatural = "";
                        goto case TTiposDadoEDI.ediAlphaAliEsquerda_____;
                    }
                    break;
                }
                case TTiposDadoEDI.ediHoraHHMM_____________:
                {
                    string sep = (_SeparadorHora == null ? "" : _SeparadorHora.ToString());
                    string Formatacao = "{0:HH" + sep + "mm}";
                    _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    break;
                }
                case TTiposDadoEDI.ediHoraHHMMSS___________:
                {
                    string sep = (_SeparadorHora == null ? "" : _SeparadorHora.ToString());
                    string Formatacao = "{0:HH" + sep + "mm" + sep + "ss}";
                    _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    break;
                }
                case TTiposDadoEDI.ediDataDDMMAAAAWithZeros:
                {
                    string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                    if ( (_ValorNatural != null) || (!ValorNatural.ToString().Trim().Equals("")))
                    {
                        string Formatacao = "{0:dd" + sep + "MM" + sep + "yyyy}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorFormatado = "00" + sep + "00" + sep + "0000";
                    }
                    break;
                }
                case TTiposDadoEDI.ediDataAAAAMMDDWithZeros:
                {
                    string sep = (_SeparadorDatas == null ? "" : _SeparadorDatas.ToString());
                    if (_ValorNatural != null)
                    {
                        string Formatacao = "{0:yyyy" + sep + "MM" + sep + "dd}";
                        _ValorFormatado = String.Format(Formatacao, _ValorNatural);
                    }
                    else
                    {
                        _ValorFormatado = "00" + sep + "00" + sep + "0000";
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Transforma o valor vindo do campo do registro EDI da propriedade ValorFormatado para o valor natural (com o tipo
        /// de dado adequado) na propriedade ValorNatural
        /// </summary>
        public void DecodificarEDIParaNatural()
        {
            if (_ValorFormatado.Trim().Equals(""))
            {
                _ValorNatural = null;
            }
            else
            {
                switch (_TipoCampo)
                {
                    case TTiposDadoEDI.ediAlphaAliEsquerda_____:
                    {
                        _ValorNatural = _ValorFormatado.ToString().Trim();
                        break;
                    }
                    case TTiposDadoEDI.ediAlphaAliDireita______:
                    {
                        _ValorNatural = _ValorFormatado.ToString().Trim();
                        break;
                    }
                    case TTiposDadoEDI.ediInteiro______________:
                    {
                        _ValorNatural = long.Parse(_ValorFormatado.ToString().Trim());
                        break;
                    }
                    case TTiposDadoEDI.ediNumericoSemSeparador_:
                    {
                        string s = _ValorFormatado.Substring(0, _ValorFormatado.Length - _QtdDecimais) + "," + _ValorFormatado.Substring(_ValorFormatado.Length - _QtdDecimais, _QtdDecimais);
                        _ValorNatural = Double.Parse(s.Trim());
                        break;
                    }
                    case TTiposDadoEDI.ediNumericoComPonto_____:
                    {
                        _ValorNatural = Double.Parse(_ValorFormatado.ToString().Replace(".", ",").Trim());
                        break;
                    }
                    case TTiposDadoEDI.ediNumericoComVirgula___:
                    {
                        _ValorNatural = Double.Parse(_ValorFormatado.ToString().Trim().Replace(".", ","));
                        break;
                    }
                    case TTiposDadoEDI.ediDataAAAAMMDD_________:
                    {
                        if (!_ValorFormatado.Trim().Equals(""))
                        {
                            string cAno = "";
                            string cMes = "";
                            string cDia = "";
                            if (_SeparadorDatas != null)
                            {
                                string[] split = _ValorFormatado.Split(_SeparadorDatas.ToCharArray());
                                cAno = split[0];
                                cMes = split[1];
                                cDia = split[2];
                            }
                            else
                            {
                                cAno = _ValorFormatado.Substring(0, 4);
                                cMes = _ValorFormatado.Substring(4, 2);
                                cDia = _ValorFormatado.Substring(6, 2);
                            }
                            if ((cDia.Equals("00") && cMes.Equals("00") && cAno.Equals("0000")))
                            {
                                _ValorNatural = null;
                            }
                            else
                            {
                                _ValorNatural = DateTime.Parse(cDia + "/" + cMes + "/" + cAno);
                            }
                        }
                        else
                        {
                            _ValorNatural = null;
                        }
                        break;
                    }
                    case TTiposDadoEDI.ediDataDDMM_____________:
                    {
                        if (!_ValorFormatado.Trim().Equals(""))
                        {
                            string cAno = "1900";
                            string cMes = "";
                            string cDia = "";
                            if (_SeparadorDatas != null)
                            {
                                string[] split = _ValorFormatado.Split(_SeparadorDatas.ToCharArray());
                                cMes = split[1];
                                cDia = split[0];
                            }
                            else
                            {
                                cMes = _ValorFormatado.Substring(2, 2);
                                cDia = _ValorFormatado.Substring(0, 2);
                            }
                            _ValorNatural = DateTime.Parse(cDia + "/" + cMes + "/" + cAno);
                        }
                        else
                        {
                            _ValorNatural = null;
                        }
                        break;
                    }
                    case TTiposDadoEDI.ediDataDDMMAAAA_________:
                    {
                        string cDia = "";
                        string cMes = "";
                        string cAno = "";
                        if (_SeparadorDatas != null)
                        {
                            string[] split = _ValorFormatado.Split(_SeparadorDatas.ToCharArray());
                            cAno = split[2];
                            cMes = split[1];
                            cDia = split[0];
                        }
                        else
                        {
                            cDia = _ValorFormatado.Substring(0, 2);
                            cMes = _ValorFormatado.Substring(2, 2);
                            cAno = _ValorFormatado.Substring(4, 4);
                        }
                        if ((cDia.Equals("00") && cMes.Equals("00") && cAno.Equals("0000")) || _ValorFormatado.Trim().Equals(""))
                        {
                            _ValorNatural = DateTime.Parse("01/01/1900"); //data start
                        }
                        else
                        {
                            _ValorNatural = DateTime.Parse(cDia + "/" + cMes + "/" + cAno);
                        }
                        break;
                    }
                    case TTiposDadoEDI.ediDataDDMMAA___________:
                    {
                        string cDia = "";
                        string cMes = "";
                        string cAno = "";
                        if (_SeparadorDatas != null)
                        {
                            string[] split = _ValorFormatado.Split(_SeparadorDatas.ToCharArray());
                            cAno = split[2];
                            cMes = split[1];
                            cDia = split[0];
                        }
                        else
                        {
                            cDia = _ValorFormatado.Substring(0, 2);
                            cMes = _ValorFormatado.Substring(2, 2);
                            cAno = _ValorFormatado.Substring(4, 2);
                        }
                        _ValorNatural = DateTime.Parse(cDia + "/" + cMes + "/" + cAno);
                        break;
                    }
                    case TTiposDadoEDI.ediDataMMAAAA___________:
                    {
                        string cDia = "01";
                        string cMes = "";
                        string cAno = "";
                        if (_SeparadorDatas != null)
                        {
                            string[] split = _ValorFormatado.Split(_SeparadorDatas.ToCharArray());
                            cAno = split[1];
                            cMes = split[0];
                        }
                        else
                        {
                            cMes = _ValorFormatado.Substring(0, 2);
                            cAno = _ValorFormatado.Substring(2, 4);
                        }
                        _ValorNatural = DateTime.Parse(cDia + "/" + cMes + "/" + cAno);
                        break;
                    }
                    case TTiposDadoEDI.ediDataMMDD_____________:
                    {
                        string cDia = "";
                        string cMes = "";
                        string cAno = "1900";
                        if (_SeparadorDatas != null)
                        {
                            string[] split = _ValorFormatado.Split(_SeparadorDatas.ToCharArray());
                            cMes = split[0];
                            cDia = split[1];
                        }
                        else
                        {
                            cDia = _ValorFormatado.Substring(2, 2);
                            cMes = _ValorFormatado.Substring(0, 2);
                        }
                        _ValorNatural = DateTime.Parse(cDia + "/" + cMes + "/" + cAno);
                        break;
                    }
                    case TTiposDadoEDI.ediHoraHHMM_____________:
                    {
                        string cHora = "";
                        string cMinuto = "";
                        if (_SeparadorHora != null)
                        {
                            string[] split = _ValorFormatado.Split(_SeparadorHora.ToCharArray());
                            cHora = split[0];
                            cMinuto = split[1];
                        }
                        else
                        {
                            cHora = _ValorFormatado.Substring(0, 2);
                            cMinuto = _ValorFormatado.Substring(2, 2);
                        }
                        _ValorNatural = DateTime.Parse(cHora + ":" + cMinuto + ":00");
                        break;
                    }
                    case TTiposDadoEDI.ediHoraHHMMSS___________:
                    {
                        string cHora = "";
                        string cMinuto = "";
                        string cSegundo = "";
                        if (_SeparadorHora != null)
                        {
                            string[] split = _ValorFormatado.Split(_SeparadorHora.ToCharArray());
                            cHora = split[0];
                            cMinuto = split[1];
                            cSegundo = split[2];
                        }
                        else
                        {
                            cHora = _ValorFormatado.Substring(0, 2);
                            cMinuto = _ValorFormatado.Substring(2, 2);
                            cSegundo = _ValorFormatado.Substring(4, 2);
                        }
                        _ValorNatural = DateTime.Parse(cHora + ":" + cMinuto + ":00");
                        break;
                    }
                    case TTiposDadoEDI.ediDataDDMMAAAAWithZeros:
                    {
                        goto case TTiposDadoEDI.ediDataDDMMAAAA_________;
                    }
                    case TTiposDadoEDI.ediDataAAAAMMDDWithZeros:
                    {
                        goto case TTiposDadoEDI.ediDataAAAAMMDD_________;
                    }
                }
            }
        }

        #endregion

        #region Métodos Privados e Protegidos

        #endregion


    }
}