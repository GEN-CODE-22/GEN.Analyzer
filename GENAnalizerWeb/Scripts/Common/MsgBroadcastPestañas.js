window.addEventListener("storage", message_receive);
function message_receive(ev) {
    if (ev.key == 'cierraAnalizer') {
        try {
            window.close();
        } catch (e) {
            
        }
    }
}

function exitAnalizer()
{
   
    window.open("/Home/Index");
    localStorage.removeItem('cierraAnalizer');
    localStorage.setItem('cierraAnalizer', 'cierraAnalizer');
    localStorage.removeItem('cierraAnalizer');

    try {
        window.close();
    } catch (e) {
       
    }
   
  
    
   
}