const Button = ({ variant, label, onClick, disabled }) => {
    const _variants = {
        primary: "btn-primary",
        secondary: "btn-secondary",
        danger: "btn-danger",
        info: "btn-info",
        warning: "btn-warning",
        success: "btn-success",
        white: "btn-white"
    };

    let btnClass = "btn-primary";
    if (variant && _variants[variant]){
        btnClass = _variants[variant];
    }

    return (
        <button type="button" className={`btn ${btnClass}`} onClick={onClick} disabled={disabled}>{label || `Button`}</button>
    );
}

export default Button;