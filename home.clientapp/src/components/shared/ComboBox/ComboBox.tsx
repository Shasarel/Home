import './ComboBox.css'

type ComboBoxProps = {
    options: string[],
    onChange: (e: React.ChangeEvent<HTMLSelectElement>) => void
}

export function ComboBox({ options, onChange }: ComboBoxProps) {
    return (
        <select defaultValue="hiddenoption" className="comboBox" onChange={onChange}>
            <option disabled value="hiddenoption" className="comboBoxHiddenOption"></option>
            {options.map((value, index) => {
                return <option className="comboBoxOption" value={index} key={index}>{value}</option>
            })}
        </select>
    );
}