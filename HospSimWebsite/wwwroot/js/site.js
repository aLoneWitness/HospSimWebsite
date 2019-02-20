function checkFormInput(){
    var inputName = document.getElementById("inputName");
    
    if(inputName.value.length === 0 || inputName.value.trim() === ""){
        swal("Form Error", "You cant leave the name field empty.", "error")
    }
    else{
        document.getElementsByTagName("form")[0].submit();
    }
}

