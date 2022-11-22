type CardProps = {
    title: string;
    value: number;
    unit: string;
    percentage: number;
    percentageColor: string;
}



export function Card({ title, value, unit, percentage, percentageColor }: CardProps) {
    return (
        <div className="card card-peity" >
            <div className="card-peity-title">{title}</div>
            <div className="card-peity-body">
                <div className="card-top">
                        <div className="card-top-number">{value}</div>
                        <div className="card-top-unit">{unit}</div>
                </div>
                <div className="card-bottom">
                    <div className="meter">
                        <span id="power-import-percentage" style={{ width: percentage, background: percentageColor }}></span>
                    </div>
                </div>
            </div>
        </div>
    );
}