import swal from 'sweetalert';

function startQueue(patients){
    swal("Welcome to the queue")
}

function showQueuedPatient(patient){
    swal({
        title: `${patient.count()} patients remaining.`,
        text: `${patient.name}, `,
        icon: "success",
        button: "Aww yiss!",
    }).then({
        
    });
}