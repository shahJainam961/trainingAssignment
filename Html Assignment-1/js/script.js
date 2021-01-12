

var text = ["KIDS", "OFFICE", "HOME", "STUDY", "BABY", "BEDROOM", "WORK FROME HOME"];
var counter = 0;
var inst = setInterval(change, 2000);

function change() {
  counter++;
  $("#changeText").slideUp(600,()=>{
    $("#changeText").text(text[counter]).slideDown(850);
  });

  if (counter >= text.length) {
    counter = 0;
  }
  

}

$(window).scroll(function () {
  if ($(this).scrollTop() > 350) {
    $('.navbar').removeClass("bg-transparent");
    $('.navbar').removeClass("navbar-light");
    $('.navbar').addClass("navbar-dark");
    $('.navbar').addClass("bg-dark");
  } else {
    $('.navbar').addClass("bg-transparent");
    $('.navbar').addClass("navbar-light");
    $('.navbar').removeClass("navbar-dark");
    $('.navbar').removeClass("bg-dark");
  }
});

$(window).scroll(function () {
  if ($(this).scrollTop() > 350) {
    $(".toTop").fadeIn();
  } else {
    $(".toTop").fadeOut();
  }
});