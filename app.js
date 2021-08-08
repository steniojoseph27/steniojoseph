// Listen for a submit
document.querySelector(".contact-form").addEventListener("submit", submitForm);
  
function submitForm(e) {
  e.preventDefault();

  //   Get input Values
  let name = document.querySelector(".name").value;
  let email = document.querySelector(".email").value;
  let subject = document.querySelector(".subject").value;
  let message = document.querySelector(".message").value;

  document.querySelector(".contact-form").reset();

  sendEmail(name, email, subject, message);
}

// Send Email Info
function sendEmail(name, email, subject, message) {
  Email
  .send({
    Host: "smtp.gmail.com",
    Username: "steniojosephs@gmail.com",
    Password: "ofsdjsrkdrpeiabb",
    To: "steniojosephs@gmail.com",
    From: `${email}`,
    Subject: `${subject}`,
    Body: `Name: ${name} <br/> Email: ${email} <br/> Subject: ${subject} <br/> Message: ${message}`,
  })
  .then((message) => alert("mail send successfully."))
}