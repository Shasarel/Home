import "./Fieldset.css"

type FieldsetProps = {
    children: React.ReactNode;
    title: string;
}

export function Fieldset({ children, title }: FieldsetProps) {
    return (
        <fieldset className="fieldset">
            <legend className="fieldset-legend">{title}</legend>
            {children}
        </fieldset>
    );
}