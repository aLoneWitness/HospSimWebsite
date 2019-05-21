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

function showError(errorMessage){
    swal(errorMessage);
}

function searchPatient(){
    window.location.href = `/patients/index?searchParams=${document.getElementById('patientSearchInput').value}`;
}



