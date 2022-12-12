import { Card } from "./Card";
import "./Card.css"

type CardDustProps = {
    title: string;
    value: number;
    unit: string;
}

export function CardDust({ title, value, unit }: CardDustProps) {
    const dustNorm = 25.0;
    var style;

    var status;

    if (value < dustNorm) {
        style = {
            background: "#70CA2C"
        }
        status = "ŚWIETNA";
    } else if (value < dustNorm * 2) {
        style = {
            background: "##D3D124"
        }
        status = "DOBRA";
    } else if (value < dustNorm * 3) {
        style = {
            background: "#EFAE16"
        }
        status = "UMIARKOWANA";
    } else if (value < dustNorm * 4) {
        style = {
            background: "#EF7728"
        }
        status = "ZŁA";
    } else {
        style = {
            background: "#B30C5A"
        }
        status = "FATALNA";
    }

    return (
        <Card title={title} value={value} unit={unit}>
            <div className="card-bottom-dust">
                <div className="card-bottom-dust-left">
                    {Math.round((value / dustNorm) * 100)} %
                </div>
                <div className="card-bottom-dust-right">
                    <div className="card-bottom-dust-status" style={style}>
                        { status }
                    </div>
                </div>
            </div>
        </Card>
    );
}