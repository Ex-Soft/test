import './index.css';

export type CellProps = {
 data?: any;
};

const Cell: React.FC<CellProps> = ({data = undefined}) => {
    return (
        <div className='cell'>
            {data}
        </div>
    )
};

export default Cell;