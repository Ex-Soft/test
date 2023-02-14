import './index.css';
import { Row } from '../../molecules';

export type TableProps = {
 data?: any[];
};

const Table: React.FC<TableProps> = ({data = undefined}) => {
    return (
        <div className='table'>
            {
                Array.isArray(data) ? 
                    data.map((item, index) => (
                        <Row key={index} data={item} />
                    )
                ) : undefined
            }
        </div>
    )
};

export default Table;