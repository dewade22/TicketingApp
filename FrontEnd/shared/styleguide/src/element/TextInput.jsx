import { useState } from "react";

const TextInput = ({
    type,
    label,
    value,
    placeholder,
    disabled,
    required,
    error,
    inputOnly,
    inputGroup,
    inputGroupIcon,
    onChange,
    className,
    customLabelClassName,
    customInputClassName
}) => {
    const [pristine, setPristine] = useState(true);

    const _onChange = (e) => {
        setPristine(false);
        onChange && onChange(e);
    };

    let id = Math.random().toString(16).slice(8);

    if (inputOnly) {
        if (inputGroup) {
            return (
                <div className="input-group">
                    <input
                        type={type}
                        className={className}
                        id={id}
                        value={value}
                        disabled={disabled || false}
                        onChange={_onChange}
                        placeholder={placeholder}
                    />
                    <span className="input-group-text p-2"><i className={inputGroupIcon}></i></span>
                </div>
            );
        }
        return (
            <input
                type={type}
                className={className}
                id={id}
                value={value}
                disabled={disabled || false}
                onChange={_onChange}
                placeholder={placeholder || required ? "This field is required" : ""}
            />
        );
    }

    let _error = error;
    if (!pristine && required && (!value || value === "")){
        _error = `${label.charAt(0).toUpperCase()}${label.toLowerCase().slice(1)} field is required`;
    }

    return (
        <div className="form-group row allign-items-center">
            <div className={className ? "" : "col-xl-5 col-md-8"}>
                <input
                    type={type}
                    className={`form-control ${customInputClassName ?? ""}`}
                    id={id}
                    value={value}
                    disabled={disabled || false}
                    onChange={_onChange}
                    placeholder={placeholder || required ? "This field is required" : ""}
                />
            </div>
            {
                _error &&
                <div className={className ? "" : "col-xl-5 col-md-8 offset-xl-2 offset-lg-3 offset-md-4"}>
                    <p className="text-danger"><small>{_error}</small></p>
                </div>
            }
        </div>
    );
}

export default TextInput;