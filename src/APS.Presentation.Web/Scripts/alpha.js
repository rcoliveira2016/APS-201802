$('.wrapper-curtida').click(function () {
    $(this).toggleClass('curtido');
});

$('.slide-horizontal').slick({
    infinite: true,
    slidesToShow: 4
});

$('#abrirModalCadastroConta').click(function () {
    $('#modalLogin').modal('hide');
    $('#btnGetLocalizacao').click();
    $('#modalCadastro').modal('show');
});

$('#btnLogOff').click(function () {
    $.post('/Home/LogOff', null, function () {
        window.location = "/";
    })
});

$('#alert-error-message').alert();

$("#alert-error-cadastro-usuario").hide();



var Post = new function () {
    let self = this;


    $('#arquivosPet').change(function () {
        self.RenderizarImagens();
    });

    $('#btnCriarPost').click(function () {
        self.CriarPost();
    });

    $(document).on('click', 'span.image-close', function () {
        $(this).parents('.wpImagem').remove();
    });

    self.RenderizarImagens = function () {

        let inputImagens = $('#arquivosPet')[0];

        if (inputImagens.files) {

            for (let i = 0; i < inputImagens.files.length; i++) {
                let reader = new FileReader();

                reader.onload = function (event) {
                    let template = $('<div>');
                    template.addClass('col-md-4 my-2 wpImagem');

                    //templkate

                    template.append($('<span class="fa fa-trash text-danger image-close"></span>'));

                    let imagem = $('<img>');
                    imagem.addClass('img-fluid imagemPetHash');

                    imagem.attr('src', event.target.result);

                    imagem.css('width', 135);
                    imagem.css('height', 150);

                    template.append(imagem);

                    $('#wpImages').prepend(template);
                }

                reader.readAsDataURL(inputImagens.files[i]);
            }
        }
    }

    self.RemoverImagem = function (index) {

    }

    self.CriarPost = function () {
        let model = {};
        model.Nome = $('#nomePet').val();
        model.Descricao = $('#descricaoPet').val();
        model.ListaTags = $('#tagsPet').tagsinput('items');
        model.ListaImagens = $('.imagemPetHash').attr('src');

        console.log(model);

        $.post('/Posts/Cadastrar/', model, function () {
            window.location = "/";
        })
    };

    self.UploudImage = function () {

    };
};

function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

var Geolocalizacao = new function () {

    let self = this;

    self.UsuarioBloqueou = false;

    self.RetornarLatLong = function (fn) {
        $.getJSON('https://ipinfo.io/geo', function (data) {
            console.log(data);
            fn(data);

        }).error(function (e) { console.log('Erro: ', e) });
    };
};

var Usuario = new function () {
    let self = this;

    let latitude;
    let longitude;

    $('#btnGetLocalizacao').click(function () {

        Geolocalizacao.RetornarLatLong(function (data) {
            let arr = data.loc.split(',');
            latitude = arr[0];
            long = arr[1];

            $('#localizacaoDisplay').val(data.city + ', ' + data.region);
        });
    });

    $('#arquivoUser').change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#previewUser').attr('src', e.target.result);
            }

            reader.readAsDataURL(this.files[0]);
        }
    });

    $('#btnCriarConta').click(function () {
        self.CriarUsuario();
    });

    let CriarModel = function () {

        let model = new FormData();
        model.append('Nome', $('#nomeUserCadastro').val());
        model.append('Login', $('#nomeUserCadastro').val());
        model.append('Email', $('#emailUserCadastro').val());
        model.append('Telefone', $('#foneUserCadastro').val());
        model.append('Senha', $('#senhaUserCadastro').val());
        model.append('ConfirmarSenha', $('#ConfirmarSenhaUserCadastro').val());
        model.append('FileUpload', $('#arquivoUser')[0].files[0])
        model.append('Latitude', latitude);
        model.append('Longitude', longitude);

        return model;
    };

    self.MonatarMensagemErro = function (mensagem) {
        var listaMensagens = mensagem.split("\\n");
        if (!listaMensagens || !listaMensagens.length)
            return mensagem;

        return
            "<div class='col-md-12'>" + 
                "<ul>" + 
                    listaMensagens.map(function (e) {
                        return "<li>" + e + "</li>";
                    }) +
                "</ul>" + 
            "</div>";
    };

    self.CriarUsuario = function () {
        let data = CriarModel();

        var sucesso = function (response) {
            window.location = "/";
        }

        var monatarMensagemErro = function (mensagem) {
            var listaMensagens = mensagem.split("\\n");
            if (!listaMensagens || listaMensagens.length < 2)
                return mensagem;

            return "<div class='row'><hr>" +
                            "<div class='col-md-12'>" +
                                "<ul>" +
                                listaMensagens.map(function (e) {
                                    return "<li>" + e + "</li>";
                                }).join("") +
                                "</ul>" +
                            "</div>" + 
                    "</div>";
        };

        $.ajax({
            type: 'post',
            url: '/Usuarios/Cadastrar',
            data: data,
            contentType: false,
            processData: false,
            dataType: 'json',
            success: sucesso,
            error: function (error) {
                if (error.status && error.status == 200) {
                    sucesso();
                }
                else {

                    if (error.statusText) {
                        $("#alert-error-cadastro-usuario").show();
                        $("#alert-error-cadastro-usuario-span").html(
                            monatarMensagemErro(error.statusText)
                        );
                    }                        
                    else
                        alert("Ocorreu um erro");
                }
            }
        });   
    };

};


$(function () {

    Geolocalizacao.RetornarLatLong(function (data) {
        let arr = data.loc.split(',');
        var latitude = arr[0];
        var long = arr[1];

        var model = {
            Latitude: latitude,
            Longitude: long,
            Cidade: data.city
        };

        $('#spanCidade').text(model.Cidade);

        $.post('/Home/AtualizarCoords/', model, function (data) { });

    });

})