var Calendario = function (parametro) {

    var NUMERO_DIAS_SEMANA = 7,
        CABECALHO_CALENDARIO_TITULO_DATA = 'cabecalho-calendario-titulo-data',
        A_PROXIMO_MES = 'proximo-mes',
        A_ANTERIOR_MES = 'anterior-mes',
        $container = document.createElement("div");

    var _legendas = {
        dias: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
        diasResumidos: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb"],
        diasMini: ["Do", "Se", "Te", "Qu", "Qu", "Se", "Sa"],
        meses: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
        mesesResumidos: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"]
    };

    var _carregar = function () {
        $container = document.getElementById(parametro.id);

        $container.appendChild(
            _montarCabecalhoCalendario(parametro.data)
        );

        $container.appendChild(
            _montarTable(parametro.data)
        );

    };

    var _criarIcone = function (classCss) {
        var i = _criarElemento('i');
        i.classList.add('fa');
        i.classList.add(classCss);
        i.classList.add('fa-fw');
        return i;
    };

    var _criarElemento = function (elemento) {
        return document.createElement(elemento);
    };

    var _obterArrayDataMes = function (dataParaConstruirMes) {

        var mes = dataParaConstruirMes.getMonth();
        var ano = dataParaConstruirMes.getFullYear();

        var dataCalendario = new Date(ano, mes, 1, 0, 0, 0, 0);
        var dataCorrentLaco = dataCalendario;

        var listaData = new Array();

        while (dataCorrentLaco.getMonth() === mes) {
            listaData.push(dataCorrentLaco);
            dataCorrentLaco = dataCorrentLaco.addDays(1);
        }

        var primerioNuremoSemanaDiaMes = dataCalendario.getDay();

        dataCorrentLaco = dataCalendario;
        for (var i = 0; i < (primerioNuremoSemanaDiaMes); i++) {
            listaData.unshift(dataCalendario.removeDays(i + 1));
        }

        var ultimoNuremoSemanaData = listaData[listaData.length - 1];
        for (var j = 1; j < (NUMERO_DIAS_SEMANA - ultimoNuremoSemanaData.getDay()); j++) {
            listaData.push(ultimoNuremoSemanaData.addDays(j));
        }

        return listaData;
    };

    var _montarTable = function (dataParaConstruirMes) {
        var table = _criarElemento("table");
        table.classList.add("calendario-io");

        var thead = _montarThead();
        var tbody = _montarTbody(dataParaConstruirMes);

        table.appendChild(thead);
        table.appendChild(tbody);

        return table;
    };

    var _montarThead = function () {
        var thead = _criarElemento("thead");
        var tr = _criarElemento("tr");

        _legendas.dias.forEach(function (e) {
            var th = _criarElemento("th");
            th.innerText = e;
            tr.appendChild(th);
        });

        thead.appendChild(tr);
        return thead;
    };

    var _montarTbody = function (dataParaConstruirMes) {

        var listaDatasDoMesNextVal = _obterArrayDataMes(dataParaConstruirMes);
        var qntSemanasNoMes = Math.ceil(listaDatasDoMesNextVal.length / NUMERO_DIAS_SEMANA);
        var tbody = _criarElemento("tbody");

        for (var i = 0; i < qntSemanasNoMes; i++) {
            var tr = _criarElemento("tr");

            for (var j = 0; j < NUMERO_DIAS_SEMANA; j++) {
                tr.appendChild(
                    _montarTdPorData(listaDatasDoMesNextVal[0], dataParaConstruirMes)
                );
                listaDatasDoMesNextVal.splice(0, 1);
            }

            tbody.appendChild(tr);
        }

        return tbody;
    };

    var _montarTdPorData = function (dataTd, dataParaConstruirMes) {
        var td = _criarElemento("td");
        if (dataTd.getMonth() !== dataParaConstruirMes.getMonth())
            td.classList.add("mes-anterior");

        td.setAttribute("data-time", dataTd.getTime());


        var div = _criarElemento("div");
        div.innerText = dataTd.getDate();

        td.appendChild(div);

        var divContainner = _criarElemento("div");
        divContainner.classList.add("container-td");
        _obterElementosAgendamentos(divContainner, dataTd);

        td.appendChild(divContainner);
        return td;
    };

    var _montarCabecalhoCalendario = function (dataParaConstruirMes) {
        var divCabecalhoCalendario = _criarElemento("div");
        var divLeft = _criarElemento("div");
        var divTitulo = _criarElemento("div");
        var divRight = _criarElemento("div");
        var p = _criarElemento("p");
        var span = _criarElemento("span");

        divLeft.innerHTML = '<a href="#" id="' + A_ANTERIOR_MES + '"><i class="fa fa-arrow-left"></i></a>';

        var data = _obterTituloDataSpan(dataParaConstruirMes);
        p.innerHTML = "<b>Data: </b>";
        span.innerText = data;
        span.setAttribute("id", CABECALHO_CALENDARIO_TITULO_DATA);
        p.appendChild(span);
        divTitulo.classList.add("titulo");
        divTitulo.appendChild(p);

        divRight.innerHTML = '<a href="#" id="' + A_PROXIMO_MES + '"><i class="fa fa-arrow-right"></i></a>';

        divCabecalhoCalendario.appendChild(divLeft);
        divCabecalhoCalendario.appendChild(divTitulo);
        divCabecalhoCalendario.appendChild(divRight);
        divCabecalhoCalendario.classList.add("cabecalho-calendario");

        return divCabecalhoCalendario;
    };

    var _obterElementosAgendamentos = function (td, data) {
        var agendamentosDataAtual = parametro.lisatAgendamento.filter(function (e) {
            var dataAgendamento = new Date(e.DataNumero);
            return dataAgendamento.getDate() === data.getDate() &&
                dataAgendamento.getMonth() === data.getMonth() &&
                dataAgendamento.getFullYear() === data.getFullYear();
        }).forEach(function (e) {
            var div = _criarElemento("div");
            div.classList.add("agendamentos");
            div.appendChild(_criarIcone('fa-plus'))
            div.appendChild(document.createTextNode(e.Cliente));
            div.setAttribute("data-id", e.Id);
            div.setAttribute("title", _obterDescricaoAgendamento(e));

            div.addEventListener('click', function (event) {
                var id = event.target.getAttribute("data-id");
                window.open(parametro.urls.atualizarAgendamento + "/" + id, "_blank");
            });

            td.appendChild(div);
        });
    };

    var _obterDescricaoAgendamento = function (agendamento) {
        var descricao = new Array();

        descricao.push("<b>Cliente:</b> " + agendamento.Cliente);
        descricao.push("<b>Descrição:</b> " + agendamento.Descricao);
        descricao.push("<b>Endereço:</b> " + agendamento.Endereco);

        return descricao.join("<br>");
    };

    var _obterTituloDataSpan = function (data) {
        return _legendas.meses[data.getMonth()] + " de " + data.getFullYear();
    };

    var _eventoProximoMes = function () {
        document.getElementById(A_PROXIMO_MES).addEventListener('click', function (e) {
            parametro.data.setMonth(
                parametro.data.getMonth() + 1
            );
            _setarTabelaPorData(parametro.data, _montarTableEventoProximoAnterior);
        });
    };

    var _eventoAnteriorMes = function () {
        document.getElementById(A_ANTERIOR_MES).addEventListener('click', function (e) {
            parametro.data.setMonth(
                parametro.data.getMonth() - 1
            );

            _setarTabelaPorData(parametro.data, _montarTableEventoProximoAnterior);
        });
    };

    var _montarTableEventoProximoAnterior = function () {
        var table = $container.querySelector("table");
        $container.removeChild(table);
        $container.appendChild(_montarTable(parametro.data));
        document.getElementById(CABECALHO_CALENDARIO_TITULO_DATA).innerText = _obterTituloDataSpan(parametro.data);
    };

    var _setarTabelaPorData = function (data, sucesso) {
        $.get(parametro.urls.buscarPorDataMes,
            { data: data.toISOString() },
            function (data) {
                parametro.lisatAgendamento = data;
                sucesso();
            }
        )
    };

    var _setarEventos = function () {
        _eventoProximoMes();
        _eventoAnteriorMes();
    };

    _carregar();
    _setarEventos();
};