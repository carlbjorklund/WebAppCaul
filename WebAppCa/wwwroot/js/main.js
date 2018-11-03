$(document).ready(function () {

   
    var listofshows = document.getElementById("showlist").getElementsByTagName("h5");
    var texts = [];
    for (var i = 0; i < listofshows.length; i++) {
        texts.push(listofshows[i].innerText);
    }

    console.log(texts);

    $("#search").autocomplete({
        minLength: 2,
        source: texts
    });
});


$(document).ready(function() {

  $("#conactform").submit(function(e) {
    e.preventDefault();
    var name = $("#inputName4").val();
    var message = $("#inputMessage4").val();
    var email = $("#inputEmail4").val();
   

    $(".error").remove();

    if (name.length < 1) {
      $("#inputName4").after('<span class="error">Your name is required..</span>');
    }
    if (message.length < 1) {
      $("#inputMessage4").after('<span class="error">This field is required</span>');
    }
    if (email.length < 1) {
      $("#inputEmail4").after('<span class="error">This field is required</span>');
    } else {
      var regEx = /^[A-Z0-9][A-Z0-9._%+-]{0,63}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/;
      var validEmail = regEx.test(email);
      if (!validEmail) {
        $("#inputEmail4").after('<span class="error">Please have a valid email</span>');
      }
    }
   
  });

  $('form[id="conactform"]').validate({
    rules: {
      name: 'required',
      message: 'required',
      email: {
        required: true,
        email: true,
      },
     
    },
    messages: {
      name: 'This field is required',
      message: 'This field is required',
      email: 'Enter a valid email',
      
    },
    submitHandler: function(form) {
      form.submit();
    }
  });

});