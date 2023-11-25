import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';

export function Card({ title, subTitle1, subTitle2, list1, list2, item1, item2, value1, value2, updateRobot }) {
    return (
        <div>
            <h1>{title}</h1>
            <div className="d-flex flex-column">
                <b>{subTitle1}: {value1}</b>
                <select 
                    onChange={(e) => updateRobot(item1, e.target.value)}
                    value={value1}
                    className="form-select"
                >
                    {list1.map(item => {
                        return <option key={item.key} value={item.key}>{item.value}</option>
                    })}
                </select>
                <b>{subTitle2}: {value2}</b>
                <select
                    onChange={(e) => updateRobot(item2, e.target.value)} 
                    value={value2}
                    className="form-select"
                >
                    {list2.map(item => {
                        return <option key={item.key} value={item.key}>{item.value}</option>
                    })}
                </select>
            </div>
        </div>
    );
}