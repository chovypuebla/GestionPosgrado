// Función para inicializar validación en formularios
function inicializarValidacionFormulario(formId) {
    $(document).ready(function () {
        var $form = $(formId);

        if ($form.length === 0) {
            console.warn('Formulario no encontrado: ' + formId);
            return;
        }

        // ==========================================
        // 1. VALIDACIÓN EN TIEMPO REAL
        // ==========================================
        $form.find('input, textarea, select').on('blur', function () {
            var $input = $(this);

            // Validar el campo
            $input.valid();

            // Agregar/quitar clases de Bootstrap
            if ($input.hasClass('input-validation-error')) {
                $input.addClass('is-invalid').removeClass('is-valid');
            } else if ($input.val() !== '') {
                $input.addClass('is-valid').removeClass('is-invalid');
            }
        });

        // Validar mientras escribe (opcional, más agresivo)
        $form.find('input[type="email"], input[type="tel"]').on('input', function () {
            var $input = $(this);
            if ($input.val() !== '') {
                $input.valid();
            }
        });

        // ==========================================
        // 2. VALIDACIÓN ANTES DE ENVIAR
        // ==========================================
        $form.on('submit', function (e) {
            // Validar formulario
            if (!$form.valid()) {
                e.preventDefault();

                // Agregar clases de Bootstrap a campos con error
                $form.find('.input-validation-error').addClass('is-invalid');
                $form.find('.input-validation-valid').addClass('is-valid');

                // Mostrar alerta general si no existe
                if ($('.alert-validation-error').length === 0) {
                    var alertHtml = `
                        <div class="alert alert-danger alert-dismissible fade show alert-validation-error" role="alert">
                            <strong><i class="bi bi-exclamation-triangle"></i> ¡Atención!</strong> 
                            Por favor complete todos los campos obligatorios correctamente.
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>
                    `;
                    $('h1').after(alertHtml);
                }

                // Scroll al primer error
                var $firstError = $('.input-validation-error:first, .is-invalid:first');
                if ($firstError.length > 0) {
                    $('html, body').animate({
                        scrollTop: $firstError.offset().top - 100
                    }, 500);

                    // Hacer foco en el primer campo con error
                    $firstError.focus();
                }

                return false;
            }
        });

        // ==========================================
        // 3. LIMPIAR MENSAJES AL CORREGIR
        // ==========================================
        $form.find('input, textarea, select').on('input change', function () {
            var $input = $(this);

            // Remover clases de error cuando el usuario empiece a corregir
            if ($input.hasClass('input-validation-error')) {
                $input.removeClass('input-validation-error is-invalid');
            }

            // Si el campo está vacío, quitar clase válida
            if ($input.val() === '') {
                $input.removeClass('is-valid');
            }
        });

        // ==========================================
        // 4. CERRAR ALERTAS
        // ==========================================
        $(document).on('click', '.alert .btn-close', function () {
            $(this).closest('.alert').fadeOut(300, function () {
                $(this).remove();
            });
        });

        // ==========================================
        // 5. PREVENIR ESPACIOS AL INICIO
        // ==========================================
        $form.find('input[type="text"], input[type="email"]').on('blur', function () {
            $(this).val($.trim($(this).val()));
        });
    });
}

// FUNCIONES AUXILIARES
// ==========================================

// Mostrar mensaje de error personalizado
function mostrarError(mensaje) {
    var alertHtml = `
        <div class="alert alert-danger alert-dismissible fade show" role="alert">
            <strong><i class="bi bi-x-circle"></i> Error:</strong> ${mensaje}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;
    $('h1').after(alertHtml);

    // Auto-cerrar después de 5 segundos
    setTimeout(function () {
        $('.alert').fadeOut(300, function () {
            $(this).remove();
        });
    }, 5000);
}

// Mostrar mensaje de éxito
function mostrarExito(mensaje) {
    var alertHtml = `
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <strong><i class="bi bi-check-circle"></i> Éxito:</strong> ${mensaje}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;
    $('h1').after(alertHtml);

    // Auto-cerrar después de 3 segundos
    setTimeout(function () {
        $('.alert').fadeOut(300, function () {
            $(this).remove();
        });
    }, 3000);
}
