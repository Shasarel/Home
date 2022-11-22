type FieldsetProps = {
    children: React.ReactNode;
    title: string;
}

export function Fieldset({ children, title }: FieldsetProps) {
    return (
        <fieldset className="card-peity-fieldset">
            <legend className="card-peity-legend">{title}</legend>
            {children}
        </fieldset>
    );
}