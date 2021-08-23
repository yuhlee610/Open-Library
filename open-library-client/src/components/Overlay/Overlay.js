import React from 'react'

function Overlay({ enable, setOpenMenu }) {
    return (
        <div
            onClick={() => setOpenMenu(false)}
            style={{
                cursor: 'pointer',
                position: 'fixed',
                inset: 0,
                zIndex: 101,
                backgroundColor: 'rgba(0,0,0,0.6)',
                display: enable ? 'block' : 'none'
            }}>
        </div>
    )
}

export default Overlay
