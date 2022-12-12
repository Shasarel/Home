import { Icon } from "../../layout/Icon/Icon";
import { Card } from "./Card";
import "./Card.css"

type CardArrowProps = {
    title: string;
    value: number;
    change: number;
    unit: string;
}

export function CardArrow({ title, value, change, unit }: CardArrowProps) {
    var iconName = "fa-solid fa-minus";
    var sign = "+";
    var iconClass ="card-bottom-arrow-right card-bottom-arrow-right-yellow";

    if (change < 0) {
        iconName = "fa-solid fa-arrow-trend-down";
        sign = "-";
        iconClass = "card-bottom-arrow-right card-bottom-arrow-right-red";
    }

    if (change > 0) {
        iconName = "fa-solid fa-arrow-trend-up";
        sign = "+";
        iconClass = "card-bottom-arrow-right card-bottom-arrow-right-green";
    }

    return (
        <Card title={title} value={value} unit={unit}>
            <div className="card-bottom-arrow-left">
                {sign} {Math.abs(change)} {unit}
            </div>
            <div className={iconClass}>
                <Icon iconName={iconName} ></Icon>
            </div>
        </Card>
    );
}