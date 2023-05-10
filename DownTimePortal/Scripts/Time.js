function chkTime(timeStr)
 {
var timRegX = /^(\d{1,2}):(\d{2}):(\d{2})?$/;
var timArr = timeStr.match(timRegX);
if (timArr == null) 
{
alert("Time is not in a valid format.");
return false;
}
hour = timArr[1];
minute = timArr[2];
second = timArr[2];
if (hour < 0 || hour > 23)
{
alert("Hour must be between 1 and 12. (or 0 and 23 for military time)");
return false;
}

if (minute < 0 || minute > 59)
 {
alert ("Minute must be between 0 and 59.");
return false;
}
if (second < 0 || second > 59) {
    alert("Minute must be between 0 and 59.");
    return false;
}

return false;
}