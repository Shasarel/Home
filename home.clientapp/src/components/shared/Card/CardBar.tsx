import { Card } from "./Card";
import "./Card.css"

type CardBarProps = {
    title: string;
    value: number;
    maxValue: number;
    unit: string;
    percentageColor: string;
}

export function CardBar({ title, value, maxValue, unit, percentageColor}: CardBarProps) {
    return (
        <Card title={title} value={value} unit={unit}>
            <div className="card-bottom-progressbar">
                <span style={{ width: CalculatePercentage(value, maxValue), background: percentageColor }}></span>
            </div>
        </Card>
    );
}

function CalculatePercentage(value: number, maxValue: number) {
    if (maxValue === 0)
        return "100%";
    return Math.round(Math.min(Math.abs(value / maxValue) * 100, 100)).toString() + "%";
}