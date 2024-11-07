let imgElement = document.getElementById('carrosel');
let currentIndex = 1;
let botoes = document.querySelectorAll('.btn_carrosel');

const img1 = "/img/carrosel1.jpeg";
const img2 = "/img/carrosel2.jpg";
const img3 = "/img/carrosel3.jpeg";

function troca1() {
    imgElement.src = img1;
    currentIndex = 1;
    botao.classList.add('ativo');
}

function troca2() {
    imgElement.src = img2;
    currentIndex = 2;
    botao.classList.add('ativo');
}

function troca3() {
    imgElement.src = img3;
    currentIndex = 3;
    botao.classList.add('ativo');
}

function autoTroca() {
    if (currentIndex === 1) {
        troca2();
    } else if (currentIndex === 2) {
        troca3();
    } else if (currentIndex === 3) {
        troca1();
    }
}

setInterval(autoTroca, 5000);



$(document).ready(function () {
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.date_time').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000');
    $('.phone').mask('0000-0000');
    $('.phone_with_ddd').mask('(00) 0000-0000');
    $('.phone_us').mask('(000) 000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
};
