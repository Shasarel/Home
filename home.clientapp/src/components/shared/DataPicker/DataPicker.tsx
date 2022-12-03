import './DataPicker.css'
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers';
import TextField from '@mui/material/TextField';

interface InputFieldDataPickerProps {
    title: string
    minDate: moment.Moment
    maxDate: moment.Moment
    date: moment.Moment |null
    setDate: (date: moment.Moment | null) => void
}

export function DataPicker({ title, date, minDate, maxDate, setDate}: InputFieldDataPickerProps) {
    return (
        <div className="inputfield-wrapper">
            <LocalizationProvider dateAdapter={AdapterMoment}>
                <DatePicker
                    label={ title }
                    value={date}
                    minDate={minDate}
                    maxDate={maxDate}
                    onChange={(newValue) => {
                        setDate(newValue);
                    }}
                    renderInput={(params) => (
                        <TextField
                            {...params}
                            sx={{
                                '.MuiInputBase-input': { width: "10rem" },
                            }}
                        />
                    )}
                />
            </LocalizationProvider>
         </div>
    );
}