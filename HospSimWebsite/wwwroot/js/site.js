function checkFormInput(){
    var inputName = document.getElementById("inputName");
    
    if(inputName.value.length === 0 || inputName.value.trim() === ""){
        swal("Form Error", "You cant leave the name field empty.", "error")
    }
    else{
        document.getElementsByTagName("form")[0].submit();
    }
}

function deletePatient(name, id){
    swal({
        title: "Patient Deletion",
        text: `Are you sure you want to delete ${name}`,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willDelete) => {
        if (willDelete) {
            window.location.href = `/patients/removepatient?index=${id}`;
        } 
        else {
            swal("The patient deletion has cancelled.");
        }
    });
}

function searchPatient(){
    window.location.href = `/patients/index?searchParams=${document.getElementById('patientSearchInput').value}`;
}


