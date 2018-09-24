var App = (function () {

    var _dialogoExcluir = function (callSim, callNao) {
        BootstrapDialog.confirm({
            title: 'Excluir',
            message: 'Deseja excluir o item?',
            label: BootstrapDialog.TYPE_DANGER,
            btnOKLabel: 'Não',
            btnOkClass: 'btn-default', 
            btnCancelLabel: 'Sim', 
            btnCancelClass: 'btn-danger', 
            callback: function (result) {                
                if (result) {
                    callNao();
                } else {
                    callSim();
                }
            }
        });
    };

    var _excluir = function (opcao) {

        var sim = function () {
            $.ajax({
                url : opcao.url,
                type: 'post',
                data: { id : opcao.id },
                success: function () {
                    if (opcao.urlRedirecionar) {
                        window.location = opcao.urlRedirecionar;
                    }
                    else {
                        opcao.botao.closest("tr").remove();
                    }
                },
                error: function(data){
                    BootstrapDialog.alert({
                        title: 'Erro',
                        message: 'Erro ao excluir:' + data,
                        label: BootstrapDialog.TYPE_DANGER
                    });
                }
            });
        };

        var nao = function () {

        };

        _dialogoExcluir(sim, nao);

    };

    return {
        dialogoExcluir: _dialogoExcluir,
        excluir: _excluir
    };

})();