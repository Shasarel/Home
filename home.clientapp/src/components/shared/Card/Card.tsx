import "./Card.css"

type CardProps = {
    title: string;
    value: number;
    unit: string;
    percentage: number;
    percentageColor: string;
}

export function Card({ title, value, unit, percentage, percentageColor }: CardProps) {
    return (
        <div className="card" >
            <div className="card-title">{title}</div>
            <div className="card-body">
                <div className="card-top">
                        <div className="card-top-number">{value}</div>
                        <div className="card-top-unit">{unit}</div>
                </div>
                <div className="card-bottom">
                    <div className="card-bottom-progressbar">
                        <span style={{ width: percentage, background: percentageColor }}></span>
                    </div>
                </div>
            </div>
        </div>
    );
}