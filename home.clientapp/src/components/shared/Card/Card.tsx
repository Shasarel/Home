import "./Card.css"

type CardProps = {
    title: string;
    value: number;
    unit: string;
    children: React.ReactNode;
}

export function Card({ title, value, unit, children }: CardProps) {
    return (
        <div className="card" >
            <div className="card-title">{title}</div>
            <div className="card-body">
                <div className="card-top">
                    <div className="card-top-number">{value}</div>
                    <div className="card-top-unit">{unit}</div>
                </div>
                <div className="card-bottom">
                    {children}
                </div>
            </div>
        </div>
    );
}