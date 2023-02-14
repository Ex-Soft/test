import './index.css';
import { Cell } from '../../atoms';

export type RowProps = {
 data?: any;
};

const Row: React.FC<RowProps> = ({data = undefined}) => {
    return (
        <div className='row'>
            {
                data && toString.call(data) === '[object Object]' ? (
                    Object.keys(data).map((key, index) => (
                        <Cell key={index} data={data[key]} />
                    ))
                ) : undefined
            }
        </div>
    )
};

export default Row;