import "./Card.css"

type CardProps = {
    title: string;
    value: number;
    maxValue: number;
    unit: string;
    percentageColor: string;
}

export function Card({ title, value, maxValue, unit, percentageColor }: CardProps) {
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
                        <span style={{ width: CalculatePercentage(value, maxValue), background: percentageColor }}></span>
                    </div>
                </div>
            </div>
        </div>
    );
}

function CalculatePercentage(value: number, maxValue: number) {
    if (maxValue == 0)
        return "0%";
    return Math.round(Math.min(Math.abs(value / maxValue) * 100, 100)).toString() + "%";
}