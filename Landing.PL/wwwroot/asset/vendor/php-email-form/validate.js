/**
* PHP Email Form Validation - v3.9
* URL: https://bootstrapmade.com/php-email-form/
* Author: BootstrapMade.com
*/
(function () {
    "use strict";
    document.addEventListener('DOMContentLoaded', function () {
        let forms = document.querySelectorAll('.php-email-form');

        forms.forEach(function (e) {
            e.addEventListener('submit', async function (event) {
                event.preventDefault();

                let thisForm = this;
                let action = thisForm.getAttribute('action');
                let recaptcha = thisForm.getAttribute('data-recaptcha-site-key');

                if (!action) {
                    displayError(thisForm, 'The form action property is not set!');
                    return;
                }

                thisForm.querySelector('.loading').classList.add('d-block');
                thisForm.querySelector('.error-message').classList.remove('d-block');
                thisForm.querySelector('.sent-message').classList.remove('d-block');

                let formData = new FormData(thisForm);

                if (recaptcha) {
                    if (typeof grecaptcha !== "undefined") {
                        try {
                            const token = await grecaptcha.execute(recaptcha, { action: 'php_email_form_submit' });
                            formData.set('recaptcha-response', token);
                            await php_email_form_submit(thisForm, action, formData);
                        } catch (error) {
                            displayError(thisForm, error.message);
                        }
                    } else {
                        displayError(thisForm, 'The reCaptcha javascript API url is not loaded!');
                    }
                } else {
                    await php_email_form_submit(thisForm, action, formData);
                }
            });
        });

        async function php_email_form_submit(thisForm, action, formData) {
            try {
                const response = await fetch(action, {
                    method: 'POST',
                    body: formData,
                    headers: { 'X-Requested-With': 'XMLHttpRequest' }
                });

                if (!response.ok) {
                    throw new Error(`${response.status} ${response.statusText} ${response.url}`);
                }

                const data = await response.text();

                thisForm.querySelector('.loading').classList.remove('d-block');

                if (data.trim() === 'OK') {
                    thisForm.querySelector('.sent-message').classList.add('d-block');
                    thisForm.reset();
                } else {
                    throw new Error(data || 'Form submission failed and no error message returned from: ' + action);
                }
            } catch (error) {
                displayError(thisForm, error.message);
            }
        }

        function displayError(thisForm, error) {
            thisForm.querySelector('.loading').classList.remove('d-block');
            thisForm.querySelector('.error-message').innerHTML = error;
            thisForm.querySelector('.error-message').classList.add('d-block');
        }
    });
})