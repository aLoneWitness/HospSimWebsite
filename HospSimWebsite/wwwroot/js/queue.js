function startQueue(patients){
    console.log("lol");
    swal({
        title: `There are ${patients.count} waiting for you`,
        text: "Welcome to the queue, press Start"
    }).then(value => {
        if(patients.count !== 0){
            patients.forEach(patient => {
               showQueuedPatient(patient); 
            });
        }
    })
}

async function showQueuedPatient(patient){
    swal({
        title: `${patient.count()} patients remaining.`,
        text: `${patient.name}, `,
        icon: "success",
        button: "Next",
    });
}